using System;
using AutoMapper;

namespace UseAsDataSourceIssue {
    public class DateTimeOffsetConverter : ITypeConverter<DateTimeOffset, DateTime>, ITypeConverter<DateTime, DateTimeOffset>, ITypeConverter<DateTimeOffset?, DateTime?>, ITypeConverter<DateTime?, DateTimeOffset?> {
        public DateTime Convert(DateTimeOffset source, DateTime destination, ResolutionContext context) {
            return (DateTime)source.DateTime;
        }
        public DateTimeOffset Convert(DateTime source, DateTimeOffset destination, ResolutionContext context) {
            return (DateTimeOffset)destination;
        }
        public DateTime? Convert(DateTimeOffset? source, DateTime? destination, ResolutionContext context) {
            if (source.HasValue)
                return (DateTime?)source.Value.DateTime;
            return null;
        }
        public DateTimeOffset? Convert(DateTime? source, DateTimeOffset? destination, ResolutionContext context) {
            if (source.HasValue)
                return (DateTimeOffset?)source.Value;
            return null;
        }
    }
}